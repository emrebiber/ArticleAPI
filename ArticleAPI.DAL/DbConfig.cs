﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleAPI.DAL
{
    public class DbConfig
    {
        public static string GetConnectionString()
        {
            return "Server=139.162.219.137;Database=article;Uid =mkvgm; Pwd=Mk1905+sql;Connect Timeout=28800;Charset=latin5";
        }
    }
}
