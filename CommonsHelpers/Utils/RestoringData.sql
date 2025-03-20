-- テーブルを削除
IF OBJECT_ID('product', 'U') IS NOT NULL
    DROP TABLE [product];
-- テーブルを作成する
CREATE TABLE [product]
(
	[id] INT IDENTITY(1,1) NOT NULL, 
    [product_id] VARCHAR(32) NOT NULL, 
    [name] NVARCHAR(30) NOT NULL, 
	[price] INT NOT NULL,
	[category_fk_id] INT NOT NULL, 
	PRIMARY KEY ([id] ASC),
	CONSTRAINT [FK_Table_ToTable] FOREIGN KEY ([category_fk_id]) REFERENCES [product_category]([id])
);
BEGIN TRANSACTION;
INSERT INTO [product]  VALUES('69af403817e44691b748f6cde073f80c',N'水性ボールペン 赤',150,1);
INSERT INTO [product]  VALUES('a4e942db87434d4985900ba14593e55f',N'水性ボールペン 黒',150,1);
INSERT INTO [product]  VALUES('6cb3976468344a71a6a5debe05abc5aa',N'水性ボールペン 青',150,1);
INSERT INTO [product]  VALUES('fccb979a0d0b4c909a1898ada46fb2b1',N'油性ボールペン 赤',130,1);
INSERT INTO [product]  VALUES('18d30718efec45cbb644af2cf50c286f',N'油性ボールペン 黒',130,1);
INSERT INTO [product]  VALUES('f073f7c3f35744ffbbdb3815e1d4b6c2',N'油性ボールペン 青',130,1);
INSERT INTO [product]  VALUES('522486256c9948ffbe9f344ac7e8aaab',N'蛍光ペン 黄',180,1);
INSERT INTO [product]  VALUES('1b1ed3388786474c8a7204ca8ceda15c',N'蛍光ペン 青',180,1);
INSERT INTO [product]  VALUES('56b1b13551fe496290a98fc780b4453b',N'蛍光ペン 緑',180,1);
INSERT INTO [product]  VALUES('4c24e51b2ecd40579ae7b0a80bfe6162',N'蛍光ペン ピンク',180,1);
INSERT INTO [product]  VALUES('6e8e29883c1d43d6b0f67e2808870643',N'色鉛筆 12色',900,1);
INSERT INTO [product]  VALUES('292ceaf0f03546e1b20b723244c1f67f',N'色鉛筆 24色',1800,1);
INSERT INTO [product]  VALUES('d4c3b32d292b40b1bc2533fc5f1ec332',N'色鉛筆 36色',2600,1);
INSERT INTO [product]  VALUES('3891934d9357403c85a5271118b106e7',N'鉛筆 黒',100,1);
COMMIT TRANSACTION;