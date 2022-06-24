﻿using System;

namespace FA.JustBlog.Services.Models.Request
{
    public class CommentRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int PostId { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public DateTime CommandTime { get; set; }
    }
}