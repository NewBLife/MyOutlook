// ***********************************************************************
// FileName:Constants
// Description:
// Project:
// Author:NewBLife
// Created:2016/11/12 13:09:30
// Copyright (c) 2016 NewBLife,All rights reserved.
// ***********************************************************************

namespace MyOutlook
{
    public static class Constants
    {
        public static readonly string APPLICATION_ID = "{your applicationID}";
        public static readonly string REDIRECT_URL = "http://localhost";
        public static readonly string[] Scopes = { "Mail.Read", "Mail.ReadWrite" };

        // 邮件一览API
        public const string MESSAGES_LIST = "https://graph.microsoft.com/v1.0/me/messages";
    }
}
