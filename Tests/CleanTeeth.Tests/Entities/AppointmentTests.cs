using System;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using CleanTeeth.Domain.Enums;
namespace CleanTeeth.Tests.Entities
{
    [TestClass]
    public class AppopintmentTests
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();
        private TimeInterval _interval = new TimeInterval(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));
        //by the time of creating an appointment the status has to be schduled and properties are correctly set and the id was set in it 

        //this is the tests to ensure creating an valid object with a valid data 
        [TestMethod]
        public void Constructor_ValidAppointment_StatusIsScheduled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);

            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentistId);
            Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
            Assert.AreEqual(_interval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Scheduled, appointment.AppointmentStatus);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        //test to check that it will throw the exception here if the start date is in the past 
        [TestMethod]
        public void Constructor_StartTimeInThePast_Throws()
        {
            var interval = new TimeInterval(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            try{
                new Appointment(_patientId, _dentistId, _dentalOfficeId, interval);
                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Cancel_CancellingAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Cancel();
            Assert.AreEqual(AppointmentStatus.Cancelled, appointment.AppointmentStatus);
        }

        [TestMethod]
        public void Complete_CompletingAppointment_ChangesStatusToCompleted()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Complete();
            Assert.AreEqual(AppointmentStatus.Completed, appointment.AppointmentStatus);
        }

        [TestMethod]
    
        public void Complete_CompletingAppointment_ThrowsIfStatutsIsNotScheduled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            try{
                appointment.Cancel();
                appointment.Complete();
                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}