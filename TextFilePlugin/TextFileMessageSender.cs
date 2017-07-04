﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Core;

namespace TextFilePlugin
{
    public class TextFileMessageSender : MessageSender
    {
        private readonly string _path;
        public TextFileMessageSender()
        {
            
        }

        protected TextFileMessageSender(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            _path = path;
        }
        public void SendMessage(Message message)
        {
            var textFileMessage = message as TextFileMessage;
            if (textFileMessage == null) return;

            using (var writer = new StreamWriter(_path + "output.txt"))
            {
                writer.WriteLine("First Name, Last Name, Number of Sales");
                writer.WriteLine(FormatMessage(textFileMessage));
            }
        }

        private string FormatMessage(TextFileMessage message)
        {
            return $"{message.FirstName}, {message.LastName}, {message.NumberOfSales}";
        }
    }
}
