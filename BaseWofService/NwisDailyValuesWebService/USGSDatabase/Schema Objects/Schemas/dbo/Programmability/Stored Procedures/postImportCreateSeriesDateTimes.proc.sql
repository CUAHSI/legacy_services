-- =============================================
-- Author:		Valentine,David
-- Create date: 2013-06-17
-- Description:	Updates the loaded series to convert from text representation to DateTime
-- =============================================
CREATE PROCEDURE postImportCreateSeriesDateTimes
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
update series
 set beginDate =case  
 when begin_date='0000' OR end_date='0000'
 then null
 when substring(begin_date,1,4) < 1755
 then '1755-01-01'
when ( LEN(begin_date) = 4 and data_type_cd in ('ad'))
then CONVERT(varchar, convert(int,begin_date)-1 )+ '-10-01'
when LEN(begin_date) = 4
then begin_date + '-01-01'
when LEN(begin_date) =7
then begin_date + '-01'
else begin_date
end ,

endDate =case 
 when begin_date='0000' OR end_date='0000'
 then null 
 when substring(end_date,1,4) < 1755
 then '1755-01-01'
 when ( LEN(end_date) = 4 and data_type_cd in ('ad'))
then CONVERT(varchar, convert(int,end_date) )+ '-09-30'
when LEN(end_date) = 4
then end_date + '-12-31'
when LEN(end_date) =7
then 
case 
when month(end_date+'-01') =2 then end_date+'-28'
when month(end_date+'-01') in (1,3,5,7,8,10,12) then end_date+'-31'
else end_date+'-30'
end
else end_date
end 
from series

END
