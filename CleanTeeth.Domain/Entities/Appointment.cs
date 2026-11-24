using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.ValueObjects;
using System.Reflection.Emit;

namespace CleanTeeth.Domain.Entities{
    //central entity that connects with time interval and tracks it with appointment status in it 
    //it has its own data setup in it 
    public class Appointment{
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus AppointmentStatus{get; private set;}
        public TimeInterval TimeInterval{get;private set;}
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        public Appointment(Guid patientId,Guid dentistId,Guid dentalOfficeId,TimeInterval timeInterval)
        {
            //ensuring basic need
            //here it ensure that the start date is valid not the earlier time 
            if (timeInterval.Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException($"The start time connot be in the past");
            }
            
            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            TimeInterval=timeInterval;
            AppointmentStatus = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();

        }
        //here we are defining behaviour of appointment
        public void Cancel()
        {
            if (AppointmentStatus != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only Scheduled appointments can be Cancelled");
            }
            AppointmentStatus=AppointmentStatus.Cancelled;
        }

        public void Complete()
        {
            if (AppointmentStatus != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled Appointments can be completed");
            }
            AppointmentStatus=AppointmentStatus.Completed;
        }

    }
}