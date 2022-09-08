﻿using System.Xml.Linq;

namespace LKDin.Server.Domain
{
    public class ChatMessage : BaseEntity
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public bool Read { get; set; }

        public override string Serialize()
        {
            return "Id=" + Id.ToString() + "|" 
                   + "Content=" + Content + "|" 
                   + "SenderId=" + SenderId + "|" 
                   + "ReceiverId=" + ReceiverId + "|"
                   + "Read=" + Read.ToString();
        }
    }
}