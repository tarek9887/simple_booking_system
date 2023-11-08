using System;
using System.Collections.Generic;

class Appointment
{
    public DateTime DateTime { get; set; }
    public string ClientName { get; set; }
    public string Description { get; set; }
}

class AppointmentBookingSystem
{
    private List<Appointment> appointments;

    public AppointmentBookingSystem()
    {
        appointments = new List<Appointment>();
    }

    public void AddAppointment(Appointment appointment)
    {
        appointments.Add(appointment);
    }

    public List<Appointment> GetAppointments(DateTime date)
    {
        return appointments.FindAll(appointment => appointment.DateTime.Date == date.Date);
    }
}

class Program
{
    static void Main(string[] args)
    {
        AppointmentBookingSystem bookingSystem = new AppointmentBookingSystem();

        while (true)
        {
            Console.WriteLine("Appointment Booking System");
            Console.WriteLine("1. Add Appointment");
            Console.WriteLine("2. View Appointments");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter client name: ");
                    string clientName = Console.ReadLine();

                    Console.Write("Enter appointment description: ");
                    string description = Console.ReadLine();

                    Console.Write("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
                    DateTime dateTime = DateTime.Parse(Console.ReadLine());

                    Appointment appointment = new Appointment
                    {
                        ClientName = clientName,
                        Description = description,
                        DateTime = dateTime
                    };

                    bookingSystem.AddAppointment(appointment);
                    Console.WriteLine("Appointment added successfully!");
                    break;

                case 2:
                    Console.Write("Enter date to view appointments (yyyy-MM-dd): ");
                    DateTime viewDate = DateTime.Parse(Console.ReadLine());
                    List<Appointment> appointments = bookingSystem.GetAppointments(viewDate);

                    Console.WriteLine($"Appointments on {viewDate.ToShortDateString()}:");

                    foreach (var app in appointments)
                    {
                        Console.WriteLine($"- Time: {app.DateTime.ToShortTimeString()}, Client: {app.ClientName}, Description: {app.Description}");
                    }
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}