ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [testUSGS_log], FILENAME = '$(Path1)$(DatabaseName)_log.LDF', FILEGROWTH = 10 %);

