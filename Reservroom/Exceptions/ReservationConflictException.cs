﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservroom.Models;

namespace Reservroom.Exceptions
{
    public class ReservationConflictException: Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }
        public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation) : base("The reservation conflicts with an existing reservation.")
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
        public ReservationConflictException(string message, Reservation existingReservation, Reservation incomingReservation) : base(message)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
        public ReservationConflictException(string message, Exception innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
    }
}
