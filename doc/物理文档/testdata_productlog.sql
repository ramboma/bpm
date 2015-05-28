
INSERT INTO dbo.ProductLog
        ( ProductInputId ,
          Time ,
          Quantity ,
          UserId ,
          Source ,
          ApproveId ,
          RelativeTask
        )
VALUES  ( 1 , -- ProductInputId - bigint
          GETDATE() , -- Time - datetime
          50 , -- Quantity - int
          0 , -- UserId - bigint
          '' , -- Source - varchar(50)
          0 , -- ApproveId - bigint
          0  -- RelativeTask - bigint
        );

INSERT INTO dbo.ProductLog
        ( ProductInputId ,
          Time ,
          Quantity ,
          UserId ,
          Source ,
          ApproveId ,
          RelativeTask
        )
VALUES  ( 2 , -- ProductInputId - bigint
          GETDATE() , -- Time - datetime
          100 , -- Quantity - int
          0 , -- UserId - bigint
          '' , -- Source - varchar(50)
          0 , -- ApproveId - bigint
          0  -- RelativeTask - bigint
        );