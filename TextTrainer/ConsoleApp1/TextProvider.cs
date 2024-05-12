using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TextProvider
    {
        private static TextProvider _instance;
        private TextProvider() { }

        public static TextProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextProvider();
                }
                return _instance;
            }
        }

        public string GetRandomText()
        {
            string[] texts = {
            "Hello World",
            "Programming in C#",
            "Design Patterns",
            "Blind Typing",
            "Object-Oriented Programming",
            "Data Structures and Algorithms",
            "Web Development with ASP.NET",
            "Machine Learning Basics",
            "Introduction to Artificial Intelligence",
            "Software Engineering Principles",
            "Computer Graphics Fundamentals",
            "Game Development with Unity",
            "Cybersecurity Essentials",
            "Internet of Things (IoT) Applications",
            "Cloud Computing Technologies",
            "Blockchain Technology Explained",
            "Quantum Computing Concepts",
            "Mobile App Development with Xamarin",
            "Big Data Analytics Fundamentals",
            "Robotics and Automation Overview",
            "Virtual Reality (VR) and Augmented Reality (AR) Basics",
            "Ethical Hacking Techniques",
            "Python Programming Essentials",
            "Java Development Basics",
            "Swift Programming Language Overview",
            "JavaScript Web Development Fundamentals",
            "Frontend Frameworks Comparison",
            "Backend Development with Node.js",
            "Database Management Systems Fundamentals",
            "UI/UX Design Principles",
            "Agile Project Management Methodologies",
            "DevOps Practices and Tools",
            "Continuous Integration and Deployment (CI/CD) Pipelines",
            "Software Testing Strategies",
            "Quality Assurance Best Practices",
            "Code Refactoring Techniques",
            "Version Control Systems Overview",
            "Open Source Contribution Guidelines",
            "Technical Interview Preparation Tips",
            "Freelancing in the Tech Industry",
            "Remote Work Productivity Hacks",
            "Startup Fundamentals",
            "Venture Capital and Angel Investment Basics",
            "Digital Marketing Strategies",
            "Personal Branding Techniques",
            "Effective Communication Skills",
            "Leadership and Team Management Principles",
            "Emotional Intelligence in the Workplace",
            "Time Management Strategies",
            "Goal Setting and Achievement Techniques",
            "Financial Planning Essentials",
            "Mindfulness and Stress Management Practices",
            "Healthy Habits for Success",
            "Environmental Sustainability Initiatives",
            "Social Impact Projects Overview",
            "Global Economic Trends Analysis",
            "Future Technologies Forecast"
        };
            Random rand = new Random();
            return texts[rand.Next(texts.Length)];
        }
    }
}
