using System;

class WritingAssignment : Assignment
{
    private string _title;
    private string _dueDate;

    public WritingAssignment(string studentName, string topic, string title, string dueDate)
        : base(studentName, topic)
    {
        _title = title;
        _dueDate = dueDate;
    }

    public string GetWritingInfo()
    {
        return "Title: " + _title + ", Due Date: " + _dueDate;
    }
}