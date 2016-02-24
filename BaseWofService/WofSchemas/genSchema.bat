tf checkout /lock:none  ..\waterOneFlow\documentation\schema\cuahsiTimeSeries.xsd
REM TOM HAS THIS CHECKED OUT
tf checkout /lock:none  .\cuahsiTimeSeries_v1_0.xsd
tf checkout /lock:none  .\cuahsiTimeSeries_v1_0.cs

REM NOT ADED YET
REM tf checkout /lock:none  ..\waterOneFlow\documentation\schema\cuahsiTimeSeries_v1_1.xsd
tf checkout /lock:none  .\cuahsiTimeSeries_v1_1.xsd
tf checkout /lock:none  .\cuahsiTimeSeries_v1_1.cs

xsd /c /n:WaterOneFlow.Schema.v1  cuahsiTimeSeries_v1_0.xsd

xsd /c /n:WaterOneFlow.Schema.v1_1  cuahsiTimeSeries_v1_1.xsd

xsd /c /n:WaterOneFlow.Schema.v2_0  cuahsiTimeSeries_v2_0.xsd

copy .\cuahsiTimeSeries.xsd ..\waterOneFlow\documentation\schema\cuahsiTimeSeries.xsd

REM copy .\cuahsiTimeSeries_v1_1.xsd ..\waterOneFlow\documentation\schema\cuahsiTimeSeries_v1_1.xsd