using System;
using System.Collections.Generic;
using System.Linq;
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }
    public void HideRandomWords(int numberToHide)
    {
        var visibleWords = _words.Where(w => !w.IsWordHidden()).ToList();
        var random = new Random();
        int count = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}: " + string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsWordHidden());
    }
}