﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Models.DTOModels
{
	public class SessionToUnreservedDTO
	{
		public int sessionId { get; set; } 
		public int userId { get; set; }
	}
}
