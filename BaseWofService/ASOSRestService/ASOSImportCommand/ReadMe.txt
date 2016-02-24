
switch (DataSetID)
            {
                case "30":
                    return "daily";
                case "10":
                    return "isd";
                case "11":
                    return "ish";
                default:
                    throw new ArgumentException("Unkonwn DatasetId " + DataSetID);
            }

datasetid=30 state=CA token=bgFcccciDafJnemlGInn connectionString=Server=localhost;Database=ASOS;Trusted_Connection=True;