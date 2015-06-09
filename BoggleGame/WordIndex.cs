﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace BoggleGame
{

    public static class WordIndex
    {
        public static ImmutableDictionary<HashSet<char>, ImmutableList<string>> CreateIndex(List<string> words)
        {
            var index = new Dictionary<HashSet<char>, IList<string>>(HashSet<char>.CreateSetComparer());
            foreach (string word in words)
            {
                HashSet<char> letters = new HashSet<char>(word);
                if (!index.Keys.Contains(letters))
                {
                    index[letters] = new List<string>();
                }
                index[letters].Add(word);
            }

            var immutableIndex = new Dictionary<HashSet<char>, ImmutableList<string>>();
            foreach (HashSet<char> key in index.Keys)
            {
                immutableIndex[key] = index[key].ToImmutableList<string>();
            }

            return immutableIndex.ToImmutableDictionary();
        }


    }
}
