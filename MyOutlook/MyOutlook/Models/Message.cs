// ***********************************************************************
// FileName:Message
// Description:
// Project:
// Author:NewBLife
// Created:2016/11/13 11:06:10
// Copyright (c) 2016 NewBLife,All rights reserved.
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace MyOutlook.Models
{
    public class Message
    {
        public BodyContent body { get; set; }
        public string bodyPreview { get; set; }
        public List<string> categories { get; set; }
        public string conversationId { get; set; }
        public DateTimeOffset createdDateTime { get; set; }
        public EmailAddress from { get; set; }
        public bool hasAttachments { get; set; }
        public string id { get; set; }
        public string importance { get; set; }
        public string inferenceClassification { get; set; }
        public string internetMessageId { get; set; }
        public bool isDeliveryReceiptRequested { get; set; }
        public bool isDraft { get; set; }
        public bool isRead { get; set; }
        public bool isReadReceiptRequested { get; set; }
        public DateTimeOffset lastModifiedDateTime { get; set; }
        public string parentFolderId { get; set; }
        public DateTimeOffset receivedDateTime { get; set; }
        public List<EmailAddress> replyTo { get; set; }
        public EmailAddress sender { get; set; }
        public DateTimeOffset sentDateTime { get; set; }
        public string subject { get; set; }
        public List<EmailAddress> toRecipients { get; set; }
        public string uniqueBody { get; set; }
        public string webLink { get; set; }

    }
}
