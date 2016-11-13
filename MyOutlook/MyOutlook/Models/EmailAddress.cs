// ***********************************************************************
// FileName:EmailAddress
// Description:
// Project:
// Author:NewBLife
// Created:2016/11/13 11:08:25
// Copyright (c) 2016 NewBLife,All rights reserved.
// ***********************************************************************

namespace MyOutlook.Models
{
    public class EmailAddress
    {
        public EmailAddressContent emailAddress { get; set; }
    }

    public class EmailAddressContent
    {
        public string name { get; set; }

        public string address { get; set; }
    }
}
