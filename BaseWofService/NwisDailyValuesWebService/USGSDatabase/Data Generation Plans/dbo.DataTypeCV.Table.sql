USE [USGS2013]
GO
/****** Object:  Table [dbo].[DataTypeCV]    Script Date: 01/15/2014 13:44:12 ******/
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Continuous', N'A quantity specified at a particular instant in time measured with sufficient frequency (small spacing) to be interpreted as a continuous record of the phenomenon.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Instantaneous', N'The phenomenon is sampled at a particular instant in time but with a frequency that is too coarse for interpreting the record as continuous.  This would be the case when the spacing is significantly larger than the support and the time scale of fluctuation of the phenomenon, such as for example infrequent water quality samples.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Cumulative', N'The values represent the cumulative value of a variable measured or calculated up to a given instant of time, such as cumulative volume of flow or cumulative precipitation.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Incremental', N'The values represent the incremental value of a variable over a time interval, such as the incremental volume of flow or incremental precipitation.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Average', N'The values represent the average over a time interval, such as daily mean discharge or daily mean temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Maximum', N'The values are the maximum values occurring at some time during a time interval, such as annual maximum discharge or a daily maximum air temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Minimum', N'The values are the minimum values occurring at some time during a time interval, such as 7-day low flow for a year or the daily minimum temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Constant Over Interval', N'The values are quantities that can be interpreted as constant over the time interval from the previous measurement.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Categorical', N'The values are categorical rather than continuous valued quantities. Mapping from Value values to categories is through the CategoryDefinitions table.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Median', N'The values represent the median over a time interval, such as daily medain discharge or daily median temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Variance', N'The values represent the variance of all of the values observed over a time interval.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Best Easy Systematic Estimator ', NULL)
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Sporadic', N'The phenomenon is sampled at a particular instant in time but with a frequency that is too coarse for interpreting the record as continuous.  This would be the case when the spacing is significantly larger than the support and the time scale of fluctuation of the phenomenon, such as for example infrequent water quality samples.')
