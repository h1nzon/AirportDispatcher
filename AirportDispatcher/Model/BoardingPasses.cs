//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirportDispatcher.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BoardingPasses
    {
        public string TicketNo { get; set; }
        public int FlightID { get; set; }
        public Nullable<int> BoardingNo { get; set; }
        public string SeatNo { get; set; }
    
        public virtual TicketFlights TicketFlights { get; set; }
    }
}
