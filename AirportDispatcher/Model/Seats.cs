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
    
    public partial class Seats
    {
        public string AircraftCode { get; set; }
        public string SeatNo { get; set; }
        public byte[] FareConditions { get; set; }
    
        public virtual Aircrafts Aircrafts { get; set; }
    }
}
