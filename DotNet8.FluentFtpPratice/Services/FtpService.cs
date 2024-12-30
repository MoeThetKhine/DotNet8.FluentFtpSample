﻿using FluentFTP;
using System.Net;

namespace DotNet8.FluentFtpPratice.Services
{
    public class FtpService
    {
        private readonly IConfiguration _configuration;
        private readonly string _hostName = string.Empty;
        private readonly string _userName = string.Empty;
        private readonly string _password = string.Empty;
        private readonly AsyncFtpClient _ftp;

        public FtpService(IConfiguration configuration)
        {
            _configuration = configuration;
            _hostName = _configuration.GetSection("FtpCredentials")["FtpHostName"]!;
            _userName = _configuration.GetSection("FtpCredentials")["FtpUserName"]!;
            _password = _configuration.GetSection("FtpCredentials")["FtpPassword"]!;
            _ftp = new AsyncFtpClient
            {
                Host = _hostName,
                Credentials = new NetworkCredential(_userName, _password)
            };
        }

        public async Task ConnectAsync()
        {
            var token = new CancellationToken();
            await _ftp.Connect(token);
        }

      
    }
}
