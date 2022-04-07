using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Hash
{

    // состояния ячеек таблицы
    [Serializable]
    public enum EntryState
    {
        Deleted,
        Filled
    }

    // запись в одной ячейке массива
    [Serializable]
    public class HashEntry
    {
        // ключ и индекс следующей записи
        public string Key { get; set; }
        public Car Value { get; set; }
        public int NextEntryIndex { get; set; }
        public EntryState State { get; set; }

        public HashEntry()
        {
            Key = null;
            Value = null;
            NextEntryIndex = -1;
            State = EntryState.Filled;
        }

        public HashEntry(string key, Car value)
        {
            Key = key;
            Value = value;
            NextEntryIndex = -1;
            State = EntryState.Filled;
        }
    }

    [Serializable]
    public class HashTable
    {
        public HashEntry[] Table { get; set; }
        public int TableSize { get; set; }

        public HashTable()
        {
            // 1009 самое меньшее простое число больше 1000
            TableSize = 1009;
            Table = new HashEntry[TableSize];
        }

        public HashTable(int tableSize)
        {
            this.TableSize = tableSize;
            Table = new HashEntry[tableSize];
        }

        void Clear()
        {
            Table = new HashEntry[TableSize];
        }

        // хеш-функция
        // полиномиальный хеш
        int Hash(string key)
        {
            // hash(s) = s0 + s1 * p + s2 * p^2 + ... ну вроде понятно
            // p берём простое большее чем размер алфавита
            // в номере вроде используются русские буквы и цифры => размер алфавита = 43

            const int p = 79;
            int result = 0, pPower = 1;

            for (int i = 0; i < key.Length; i++)
            {
                result += key[i] % TableSize * pPower % TableSize;
                result %= TableSize;
                pPower *= p;
                pPower %= TableSize;
            }

            return result;
        }

        // проверить что ключа нет в цепочке
        bool IsKeyInTable(int chainHeadIndex, string key)
        {
            // идём пока цепочка не закончится
            while (chainHeadIndex != -1)
            {
                // ячейка не удалена и ключ совпадает
                if (Table[chainHeadIndex].State != EntryState.Deleted && Table[chainHeadIndex].Key == key)
                    return true;

                chainHeadIndex = Table[chainHeadIndex].NextEntryIndex;
            }

            return false;
        }

        // найти удалённую ячейку в цепочке, если такой нет то вернуть -1
        int FindDeletedEntryIndexInChain(int chainHeadIndex)
        {
            // идём пока не конец и пока не встретим удалённую
            while (chainHeadIndex != -1 && Table[chainHeadIndex].State != EntryState.Deleted)
                chainHeadIndex = Table[chainHeadIndex].NextEntryIndex;

            return chainHeadIndex;

        }

        int FindEmptyOrDeletetedEntryIndex(int startIndex)
        {
            // будем идти вначале вперёд, а потом назад(если впереди не найдём) с шагом 1
            for (int i = startIndex + 1; i < TableSize; i++)
                if (Table[i] == null || Table[i].State == EntryState.Deleted)
                    return i;

            for (int i = startIndex - 1; i >= 0; i--)
                if (Table[i] == null || Table[i].State == EntryState.Deleted)
                    return i;

            // не нашли пустую ячеку, выкинем исключение
            throw new InvalidOperationException("Таблица переполнена");
        }

        int FindChainTail(int chainHeadIndex)
        {
            while (Table[chainHeadIndex].NextEntryIndex != -1)
                chainHeadIndex = Table[chainHeadIndex].NextEntryIndex;

            return chainHeadIndex;
        }

        public void Add(string key, Car value)
        {
            int index = Hash(key);

            //попали в пустую ячейку, сразу запись
            if (Table[index] == null)
            {
                Table[index] = new HashEntry(key, value);
            }
            else
            {
                // вначале проверка, что такого ключа нет
                if (IsKeyInTable(index, key))
                    throw new InvalidOperationException("Такой ключ уже добавлен в таблицу");

                // найдём вначале удалённую ячейку
                int deletedEntryIndex = FindDeletedEntryIndexInChain(index);

                // есть удалённая, просто записываем туда
                if (deletedEntryIndex != -1)
                {
                    Table[deletedEntryIndex].Key = key;
                    Table[deletedEntryIndex].Value = value;
                    Table[deletedEntryIndex].State = EntryState.Filled;
                }
                else
                {
                    // ищем ячейку вне цепочки

                    int entryIndex = FindEmptyOrDeletetedEntryIndex(index);
                    int chainTailIndex = FindChainTail(index);

                    
                    Table[chainTailIndex].NextEntryIndex = entryIndex;

                    if (Table[entryIndex] == null)
                        Table[entryIndex] = new HashEntry(key, value);
                    else
                    {
                        Table[deletedEntryIndex].Key = key;
                        Table[deletedEntryIndex].Value = value;
                        Table[deletedEntryIndex].State = EntryState.Filled;
                    }

                }
            }
        }

        int FindEntryIndexInChain(string key, int chainHeadIndex)
        {
            while (chainHeadIndex != -1 && (Table[chainHeadIndex].Key != key || Table[chainHeadIndex].State == EntryState.Deleted))
                chainHeadIndex = Table[chainHeadIndex].NextEntryIndex;

            return chainHeadIndex;
        }

        public Car Find(string key)
        {
            int index = Hash(key);

            // проверим, что цепочка пустая
            if (Table[index] == null)
                return null;

            int entryIndex = FindEntryIndexInChain(key, index);

            if (entryIndex == -1)
                return null;

            return Table[entryIndex].Value;
        }

        public void Remove(string key)
        {
            int index = Hash(key);

            if (Table[index] != null)
            {
                int entryIndex = FindEntryIndexInChain(key, index);

                if (entryIndex != -1)
                {
                    Table[entryIndex].State = EntryState.Deleted;
                    Table[entryIndex].Value = null;
                }
            }
        }

        public List<string> ToStringList()
        {
            List<string> res = new List<string>();
            
            foreach (var i in Table)
                if (i != null && i.State != EntryState.Deleted)
                    res.Add(i.Value.ToString());

            return res;
        }

        public void WriteToTextFile(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);

            foreach (var i in Table)
                if (i != null && i.State != EntryState.Deleted)
                    i.Value.WriteToTextFile(file);

            file.Close();
        }

        public void TryReadFromTextFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName);

            bool isOk = true;

            // отчищаем хеш-таблицу перед считыванием
            Clear();

            while (!file.EndOfStream && isOk)
            {
                Car newCar = new Car();
                bool res = newCar.TryReadFromTextFile(file);

                // если не могли считать при этом мы не дошли до конца файла, то сообщим об ошибке чтения
                // считали мусор в конце файла
                if (!res && !file.EndOfStream)
                    isOk = false;
                else if (res)
                {
                    try
                    {
                        Add(newCar.CarNumber, newCar);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Произошла ошибка при считывании файла\n" + 
                            e.Message);
                        
                        isOk = false;
                    }
                }
            }

            file.Close();
        }
    }
}
