using System;
using System.Collections.Generic;
using System.Data;
using ServiceStack.Data;

namespace ServiceStack.OrmLite
{
    /// <summary>
    /// Allow for mocking and unit testing by providing non-disposing 
    /// connection factory with injectable IDbCommand and IDbTransaction proxies
    /// </summary>
    public class OrmLiteConnectionFactory : IDbConnectionFactory
    {
        public OrmLiteConnectionFactory()
            : this(null, null, true) { }

        public OrmLiteConnectionFactory(string connectionString)
            : this(connectionString, null, true) { }

        public OrmLiteConnectionFactory(string connectionString, IOrmLiteDialectProvider dialectProvider)
            : this(connectionString, dialectProvider, true) { }

        public OrmLiteConnectionFactory(string connectionString, IOrmLiteDialectProvider dialectProvider, bool setGlobalDialectProvider)
        {
            ConnectionString = connectionString;
            AutoDisposeConnection = connectionString != ":memory:";
            this.DialectProvider = dialectProvider ?? OrmLiteConfig.DialectProvider;

            if (setGlobalDialectProvider && dialectProvider != null)
            {
                OrmLiteConfig.DialectProvider = dialectProvider;
            }

            this.ConnectionFilter = x => x;
        }

        public IOrmLiteDialectProvider DialectProvider { get; set; }

        public string ConnectionString { get; set; }

        public bool AutoDisposeConnection { get; set; }

        public Func<IDbConnection, IDbConnection> ConnectionFilter { get; set; }

        /// <summary>
        /// Force the IDbConnection to always return this IDbCommand
        /// </summary>
        public IDbCommand AlwaysReturnCommand { get; set; }

        /// <summary>
        /// Force the IDbConnection to always return this IDbTransaction
        /// </summary>
        public IDbTransaction AlwaysReturnTransaction { get; set; }

        public Action<OrmLiteConnection> OnDispose { get; set; }

        private OrmLiteConnection ormLiteConnection;
        private OrmLiteConnection OrmLiteConnection
        {
            get
            {
                if (ormLiteConnection == null)
                {
                    ormLiteConnection = new OrmLiteConnection(this);
                }
                return ormLiteConnection;
            }
        }

        internal string DbBase { get; private set; }

        public IDbConnection OpenDbConnection()
        {
            var connection = CreateDbConnection();
            connection.Open();

            DbBase = connection.Database;

            return connection;
        }


        public IDbConnection CreateDbConnection()
        {
            if (this.ConnectionString == null)
                throw new ArgumentNullException("ConnectionString", "ConnectionString must be set");

            var connection = AutoDisposeConnection
                ? new OrmLiteConnection(this)
                : OrmLiteConnection;

            //moved setting up the ConnectionFilter to OrmLiteConnection.Open
            //return ConnectionFilter(connection);
            DbBase = connection.Database;

            return connection;
        }

        public IDbConnection OpenDbConnection(string connectionKey)
        {
            OrmLiteConnectionFactory factory;
            if (!NamedConnections.TryGetValue(connectionKey, out factory))
                throw new KeyNotFoundException("No factory registered is named " + connectionKey);

            IDbConnection connection = factory.AutoDisposeConnection
                ? new OrmLiteConnection(factory)
                : factory.OrmLiteConnection;

            //moved setting up the ConnectionFilter to OrmLiteConnection.Open
            //connection = factory.ConnectionFilter(connection);
            connection.Open();

            DbBase = connection.Database;

            return connection;
        }

        private static Dictionary<string, OrmLiteConnectionFactory> namedConnections;
        public static Dictionary<string, OrmLiteConnectionFactory> NamedConnections
        {
            get
            {
                return namedConnections = namedConnections
                    ?? (namedConnections = new Dictionary<string, OrmLiteConnectionFactory>());
            }
        }

        public void RegisterConnection(string connectionKey, string connectionString, IOrmLiteDialectProvider dialectProvider)
        {
            RegisterConnection(connectionKey, new OrmLiteConnectionFactory(connectionString, dialectProvider, setGlobalDialectProvider: false));
        }

        public void RegisterConnection(string connectionKey, OrmLiteConnectionFactory connectionFactory)
        {
            NamedConnections[connectionKey] = connectionFactory;
        }
    }

    public static class OrmLiteConnectionFactoryExtensions
    {
        /// <summary>
        /// Alias for OpenDbConnection
        /// </summary>
        public static IDbConnection Open(this IDbConnectionFactory connectionFactory)
        {
            return connectionFactory.OpenDbConnection();
        }

        /// <summary>
        /// Alias for OpenDbConnection
        /// </summary>
        public static IDbConnection Open(this IDbConnectionFactory connectionFactory, string namedConnection)
        {
            return ((OrmLiteConnectionFactory)connectionFactory).OpenDbConnection(namedConnection);
        }

        public static IDbConnection OpenDbConnection(this IDbConnectionFactory connectionFactory, string namedConnection)
        {
            return ((OrmLiteConnectionFactory)connectionFactory).OpenDbConnection(namedConnection);
        }
    }
}