﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Database
{
    class DBLayerSql : IDataLayer
    {
        public void ConnectDB(string connectionString)
        {
            throw new NotImplementedException();
        }

        public bool CreatePlayer(string name)
        {
            throw new NotImplementedException();
        }

        public bool CreateTeam(string name)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlayer(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTeam(string id)
        {
            throw new NotImplementedException();
        }

        public List<Player> Players()
        {
            throw new NotImplementedException();
        }

        public Player ReadPlayer(string id)
        {
            throw new NotImplementedException();
        }

        public Team ReadTeam(string id)
        {
            throw new NotImplementedException();
        }

        public Player ShowPlayer(string id)
        {
            throw new NotImplementedException();
        }

        public List<Team> Teams()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePlayer(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTeam(string id)
        {
            throw new NotImplementedException();
        }
    }
}
