
IF NOT EXISTS (SELECT TOP 1 FROM [schDictinaries].[tDictionaries] WHERE [Id] = 1)
    BEGIN INSERT INTO [schDictinaries].[tDictionaries] VALUES(1, N'ActivityTypes') END 
ELSE
    BEGIN UPDATE [schDictinaries].[tDictionaries] SET [Name] = N'ActivityTypes' WHERE [Id] = 1 END

IF NOT EXISTS (SELECT TOP 1 FROM [schDictinaries].[tDictionaryNames] WHERE [DictionaryId] = 1 AND [Culture] = 'PL')
    BEGIN INSERT INTO [schDictinaries].[tDictionaryNames] ([Name], [Culture], [DictionaryId]) VALUES(N'Rodzaje aktywności', 'PL', 1) END 
ELSE 
    BEGIN UPDATE [schDictinaries].[tDictionaryNames] SET [Name] = N'Rodzaje aktywności' WHERE [DictionaryId] = 1 AND [Culture] = 'PL' END

IF NOT EXISTS (SELECT TOP 1 FROM [schDictinaries].[tDictionaryNames] WHERE [DictionaryId] = 1 AND [Culture] = 'EN')
    BEGIN INSERT INTO [schDictinaries].[tDictionaryNames] ([Name], [Culture], [DictionaryId]) VALUES(N'Activity types', 'EN', 1) END 
ELSE 
    BEGIN UPDATE [schDictinaries].[tDictionaryNames] SET [Name] = N'Activity types' WHERE [DictionaryId] = 1 AND [Culture] = 'EN' END

