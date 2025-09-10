using System;
using System.Collections.Generic;
public class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What do I love most about my family?",
        "What is my favorite scripture?",
        "What do I love most about your friends?"
    };
    private Random random = new Random();
    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}