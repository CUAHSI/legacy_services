﻿ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [testUSGS], FILENAME = '$(Path2)$(DatabaseName).mdf', FILEGROWTH = 102400 KB) TO FILEGROUP [PRIMARY];

