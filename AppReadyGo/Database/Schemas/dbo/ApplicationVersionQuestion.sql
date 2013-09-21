﻿
CREATE TABLE [dbo].[ApplicationVersionQuestion](
	[ApplicationVersionQuestionyId] [int] NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[VersionId] [int] NOT NULL,
	[SurveyQuestionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationVersionQuestionyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ApplicationVersionQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationVersionQuestion_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([Id])
GO

ALTER TABLE [dbo].[ApplicationVersionQuestion] CHECK CONSTRAINT [FK_ApplicationVersionQuestion_Application]
GO

ALTER TABLE [dbo].[ApplicationVersionQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationVersionQuestion_SurveyQuestion] FOREIGN KEY([SurveyQuestionId])
REFERENCES [dbo].[SurveyQuestion] ([SurveyQuestionId])
GO

ALTER TABLE [dbo].[ApplicationVersionQuestion] CHECK CONSTRAINT [FK_ApplicationVersionQuestion_SurveyQuestion]
GO


