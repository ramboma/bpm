INSERT INTO dbo.ProductInput
        ( ProductId ,
          Time ,
          Quantity ,
          UserId ,
          Source ,
          ApproveId ,
          RelativeTask ,
          StorageNum ,
          Shelf
        )
VALUES  ( 110018888888 , -- ProductId - bigint
          GETDATE() , -- Time - datetime
          100 , -- Quantity - int
          0 , -- UserId - bigint
          '' , -- Source - varchar(50)
          1 , -- ApproveId - bigint
          0 , -- RelativeTask - bigint
          '11' , -- StorageNum - varchar(20)
          '22'  -- Shelf - varchar(20)
        );
        INSERT INTO dbo.ProductInput
        ( ProductId ,
          Time ,
          Quantity ,
          UserId ,
          Source ,
          ApproveId ,
          RelativeTask ,
          StorageNum ,
          Shelf
        )
VALUES  ( 110018888888 , -- ProductId - bigint
          GETDATE() , -- Time - datetime
          200 , -- Quantity - int
          0 , -- UserId - bigint
          '' , -- Source - varchar(50)
          1 , -- ApproveId - bigint
          0 , -- RelativeTask - bigint
          '11' , -- StorageNum - varchar(20)
          '22'  -- Shelf - varchar(20)
        );