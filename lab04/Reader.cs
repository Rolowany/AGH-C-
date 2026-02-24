namespace reader{

    class Reader<T>
    {
        public List<T> ReadList(string path, Func<string[], T> generate)
        {
            var list = new List<T>();

            foreach (var line in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = line.Split(',');

                T item = generate(values);
                list.Add(item);
            }

            return list;
        }
    }

}
