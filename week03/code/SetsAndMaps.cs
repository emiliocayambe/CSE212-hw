using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var wordSet = new HashSet<string>(words);
        var visited = new HashSet<string>();
        var result = new List<string>();

    foreach (string word in words)
        {
            // Reverse the 2-character word (e.g., "am" -> "ma")
            char[] chartArray = word.ToCharArray();
            Array.Reverse(chartArray);

            string reversed = new string(chartArray);
            if (word == reversed || visited.Contains(word))
            {
                continue;
            }    
        // If the reversed word exists in our original word set
        if (wordSet.Contains(reversed))
      {
                result.Add($"{word} & {reversed}");
        
        // Mark both words as visited to avoid adding the reverse pair later
            visited.Add(word);
            visited.Add(reversed);
      }


    }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            
            // Ensure the line has at least 4 columns (index 3) to avoid IndexOutOfRangeException
            if (fields.Length > 3)
            {
                // Clean up any extra whitespace from the degree string
                string degree = fields[3].Trim();

                // If the degree is already in the dictionary, increment its count; otherwise, initialize it to 1
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        
        // Normalize both words: convert to lowercase and remove spaces
        string cleanWord1 = word1.ToLower().Replace(" ", "");
        string cleanWord2 = word2.ToLower().Replace(" ", "");

        // If lengths differ after cleaning, they cannot be anagrams
        if (cleanWord1.Length != cleanWord2.Length)
        {
            return false;
        }

        // Use a dictionary to count letter frequencies
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();

        // Populate dictionary with counts from the first word
        foreach (char c in cleanWord1)
        {
            if (letterCounts.ContainsKey(c))
            {
                letterCounts[c]++;
            }
            else
            {
                letterCounts[c] = 1;
            }
        }

        // Subtract counts using the second word
        foreach (char c in cleanWord2)
        {
            // If the character is not in the dictionary or its count is already 0, they are not anagrams
            if (!letterCounts.ContainsKey(c) || letterCounts[c] == 0)
            {
                return false;
            }
            letterCounts[c]--;
        }

        // If all checks passed, they are anagrams
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        // Check if featureCollection or its Features list is null to avoid runtime exceptions
        if (featureCollection?.Features == null)
        {
            return Array.Empty<string>();
        }

        List<string> summaries = new List<string>();

        // Iterate through each earthquake feature in the collection
    foreach (var feature in featureCollection.Features)
        {
            // Ensure properties and required values are not null
            if (feature?.Properties != null)
            {
                string place = feature.Properties.Place ?? "Unknown location";
                double mag = feature.Properties.Mag;

                // Format the description to strictly match what the test expects: " - Mag "
                summaries.Add($"{place} - Mag {mag}");
            }
        }

        // Return the array of summaries
        return summaries.ToArray();
    }
}