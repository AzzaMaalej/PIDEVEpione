namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif_table_appointment : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rates", new[] { "appointment_AppointmentId" });
            DropIndex("dbo.Rates", new[] { "patient_Id" });
            RenameColumn(table: "dbo.Appointments", name: "doctor_Id", newName: "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "patient_Id", newName: "PatientId");
            RenameIndex(table: "dbo.Appointments", name: "IX_doctor_Id", newName: "IX_DoctorId");
            RenameIndex(table: "dbo.Appointments", name: "IX_patient_Id", newName: "IX_PatientId");
            AddColumn("dbo.Appointments", "Location", c => c.String());
            AddColumn("dbo.Appointments", "AppointmentState", c => c.String(nullable: false, defaultValue: "In_progress"));
            CreateIndex("dbo.Rates", "Appointment_AppointmentId");
            CreateIndex("dbo.Rates", "Patient_Id");
            DropColumn("dbo.Appointments", "Disease");
            DropColumn("dbo.Appointments", "state");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "state", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "Disease", c => c.String());
            DropIndex("dbo.Rates", new[] { "Patient_Id" });
            DropIndex("dbo.Rates", new[] { "Appointment_AppointmentId" });
            DropColumn("dbo.Appointments", "AppointmentState");
            DropColumn("dbo.Appointments", "Location");
            RenameIndex(table: "dbo.Appointments", name: "IX_PatientId", newName: "IX_patient_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_DoctorId", newName: "IX_doctor_Id");
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "patient_Id");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId", newName: "doctor_Id");
            CreateIndex("dbo.Rates", "patient_Id");
            CreateIndex("dbo.Rates", "appointment_AppointmentId");
        }
    }
}
