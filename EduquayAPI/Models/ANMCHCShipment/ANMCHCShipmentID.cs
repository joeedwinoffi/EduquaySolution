﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMCHCShipment
{
    public class ANMCHCShipmentID : IFill
    {
        public string ShipmentID { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.ShipmentID = Convert.ToString(reader["ShipmentID"]);
        }
    }
}
