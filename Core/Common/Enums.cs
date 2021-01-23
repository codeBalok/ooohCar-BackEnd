using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public static class Enums
    {
        public enum ApplicationRole
        {
            Admin = 1,
            Manager = 2,
            User = 3,
            Student = 4,
            SuperAdmin = 5
        }
        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            pdf,
            unknown
        }

        public enum TaskStatus
        {
            Open = 1,
            Cancel = 2,
            Completed = 3
        }
        public enum TaskPriority
        {
            Low = 1,
            High = 2,
            Urgent = 3
        }
        public enum UnionMember
        {
            No,
            Yes
        }
        public enum PaymentMethod
        {
            Bank,
            Cash,
            Cheque
        }
        public enum EmployeeLoan
        {
            Yes,
            No
        }
        public enum AppointmentStatus
        {
            Pending = 1,
            Completed = 2,
            Deleted = 3,
            Cancelled = 4
        }
        public enum NotificationTypeForUser
        {
            SENT,
            RECEIVED
        }
        public enum NotificationType
        {
            AddTask = 1,
            CancelTask = 2,
            CompleteTask = 3,
            AddAppointment = 4,
            CancelAppointment = 5,
            CompleteAppointment = 6,
            DeleteAppointment = 7,
            AddStudent = 8,
            ActivateStudent = 9,
            DeactivateStudent = 10,
            UpdateStudent = 11
        }
    }
}
