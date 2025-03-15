using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Specialized;
using System.Diagnostics;
using Microsoft.Win32;

class FileManager
{
    private static string lastDeletedPath = string.Empty;

    public static void CreateFile(string path)
    {
        try 
        { 
            using (File.Create(path));
            MessageBox.Show("Файл успешно создан!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public static void CreateDirectory(string path)
    {

        try
        {
            Directory.CreateDirectory(path);
            MessageBox.Show("Папка успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public static void DeleteFile(string path)
    {
        try
        {
            lastDeletedPath = path;
            File.Delete(path);
            MessageBox.Show("Файл успешно удален!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public static void DeleteDirectory(string path)
    {
        try
        {
            lastDeletedPath = path;
            Directory.Delete(path, true);
            MessageBox.Show("Папка успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) 
        {
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public static int Copy(ListView listView)
    {
        try
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите файл или папку для копирования/перемещения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }

            StringCollection paths = new StringCollection();

            foreach (ListViewItem item in listView.SelectedItems)
            {
                string selectedPath = item.Tag.ToString();
                if (File.Exists(selectedPath) || Directory.Exists(selectedPath))
                {
                    paths.Add(selectedPath);
                }
            }

            if (paths.Count > 0)
            {
                Clipboard.SetFileDropList(paths);
                MessageBox.Show("Файл(ы) скопированы в буфер обмена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при копировании!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 0;
        }
    }

    public static void Paste(string destinationPath)
    {
        try
        {
            if (!Clipboard.ContainsFileDropList())
            {
                MessageBox.Show("Буфер обмена пуст или не содержит файлов/папок.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringCollection files = Clipboard.GetFileDropList();

            foreach (string sourcePath in files)
            {
                string targetPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));

                if (File.Exists(sourcePath))
                {
                    if (File.Exists(targetPath))
                    {
                        DialogResult result = MessageBox.Show(
                            $"Файл {Path.GetFileName(sourcePath)} уже существует. Заменить?",
                            "Подтверждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                            continue;
                    }

                    File.Copy(sourcePath, targetPath, true);
                }
                else if (Directory.Exists(sourcePath))
                {
                    if (Directory.Exists(targetPath))
                    {
                        DialogResult result = MessageBox.Show(
                            $"Папка {Path.GetFileName(sourcePath)} уже существует. Заменить?",
                            "Подтверждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                            continue;
                    }

                    CopyDirectory(sourcePath, targetPath);
                }
            }

            MessageBox.Show("Файл(ы)/папка(и) успешно вставлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static void CopyDirectory(string sourceDir, string destinationDir)
    {
        try
        {

            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            string[] files = Directory.GetFiles(sourceDir);
            if (files.Length == 0)
            {
                return;
            }

            foreach (string file in files)
            {
                string targetFilePath = Path.Combine(destinationDir, Path.GetFileName(file));
                File.Copy(file, targetFilePath, true);
            }

            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string targetSubDir = Path.Combine(destinationDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, targetSubDir);
            }

            Debug.WriteLine($"Копирование завершено: {sourceDir}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    public static void MoveFiles(string destinationPath)
    {
        try
        {
            if (!Clipboard.ContainsFileDropList())
            {
                MessageBox.Show("Буфер обмена пуст или не содержит файлов/папок.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringCollection files = Clipboard.GetFileDropList();

            foreach (string sourcePath in files)
            {
                string targetPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));

                if (File.Exists(targetPath) || Directory.Exists(targetPath))
                {
                    DialogResult result = MessageBox.Show(
                        $"Объект '{Path.GetFileName(sourcePath)}' уже существует в '{destinationPath}'. Заменить?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        continue;

                    try
                    {
                        if (Directory.Exists(targetPath))
                        {
                            Directory.Delete(targetPath, true); 
                        }
                        else if (File.Exists(targetPath))
                        {
                            File.Delete(targetPath); 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось удалить существующий объект: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }


                try
                {
                    if (File.Exists(sourcePath))
                    {
                        File.Move(sourcePath, targetPath); 
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        Directory.Move(sourcePath, targetPath); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при перемещении '{Path.GetFileName(sourcePath)}': {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Файл(ы)/папка(и) успешно перемещены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void TryNavigateToPath(TextBox PathTextBox, ref string currentPath, ListView ListView)
    {
        string path = PathTextBox.Text.Trim();

        if (Directory.Exists(path))
        {
            LoadFiles(path, ref currentPath, ListView, PathTextBox);
        }
        else if (path == "MyComputer")
        {
            LoadFiles("MyComputer", ref currentPath, ListView, PathTextBox);
        }
        else
        {
            MessageBox.Show("Данная директория не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private static string GetFileType(string extension)
    {
        if (string.IsNullOrEmpty(extension))
            return "Неизвестный файл";

        using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(extension))
        {
            if (key != null)
            {
                object value = key.GetValue("");
                if (value != null)
                {
                    using (RegistryKey fileTypeKey = Registry.ClassesRoot.OpenSubKey(value.ToString()))
                    {
                        if (fileTypeKey != null)
                        {
                            object typeName = fileTypeKey.GetValue("");
                            return typeName != null ? typeName.ToString() : "Неизвестный тип";
                        }
                    }
                }
            }
        }
        return "Неизвестный тип";
    }

    private static string FormatSize(long size)
    {
        if (size < 1024)
            return size + " Б";
        else if (size < 1024 * 1024)
            return (size / 1024.0).ToString("0.##") + " КБ";
        else if (size < 1024 * 1024 * 1024)
            return (size / (1024.0 * 1024)).ToString("0.##") + " МБ";
        else
            return (size / (1024.0 * 1024 * 1024)).ToString("0.##") + " ГБ";
    }

    public static void LoadFiles(string path, ref string currentPath, ListView ListViewFiles, TextBox PathTextBox)
    {
        string oldPath = currentPath;
        try
        {
            ListViewFiles.Items.Clear();
            PathTextBox.Text = path;
            currentPath = path;

            if (path == "MyComputer")
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    ListViewItem item = new ListViewItem(drive.Name);
                    try
                    {
                        item.SubItems.Add("Диск"); 
                        item.SubItems.Add(FormatSize(drive.TotalSize-drive.AvailableFreeSpace)); 
                        item.Tag = drive.Name;
                        ListViewFiles.Items.Add(item);
                    }
                    catch (Exception)
                    {
                        item.SubItems.Add("Устройство не готово");
                        item.Tag = drive.Name;
                        ListViewFiles.Items.Add(item);
                    }
                }
            }
            else if (Directory.Exists(path))
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    ListViewItem item = new ListViewItem(dirInfo.Name);
                    item.SubItems.Add("Папка"); 
                    item.SubItems.Add(""); 
                    item.Tag = dir;
                    ListViewFiles.Items.Add(item);
                }

                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fileInfo.Name);

             
                    string fileType = GetFileType(fileInfo.Extension);
                    item.SubItems.Add(fileType);

                    item.SubItems.Add(FormatSize(fileInfo.Length));

                    item.Tag = file;
                    ListViewFiles.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Путь не существует.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LoadFiles(oldPath, ref currentPath, ListViewFiles, PathTextBox);
        }
    }

    public static void RenameItem(string oldPath, string newName, ListView ListViewFiles, TextBox PathTextBox)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Имя не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            if (File.Exists(oldPath))
            {
                string newFilePath = Path.Combine(Path.GetDirectoryName(oldPath), newName);
                File.Move(oldPath, newFilePath); 
            }
            else if (Directory.Exists(oldPath))
            {
                string newDirPath = Path.Combine(Path.GetDirectoryName(oldPath), newName);
                Directory.Move(oldPath, newDirPath); 
            }
            else
            {
                MessageBox.Show("Файл или папка не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

      
            LoadFiles(Path.GetDirectoryName(oldPath), ref oldPath, ListViewFiles, PathTextBox);

            MessageBox.Show("Файл или папка успешно переименованы.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при переименовании: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void ShowFileProperties(string path)
    {
        try
        {
            FileAttributes attr = File.GetAttributes(path);
            string type = "";
            string size = "-";
            string created = "";
            string modified = "";
            string accessed = "";

            if (Directory.Exists(path))
            {
                DriveInfo drive = DriveInfo.GetDrives().FirstOrDefault(d => d.Name == path);
                if (drive != null)
                {
                    type = "Локальный диск";
                    size = FormatSize(drive.TotalSize - drive.AvailableFreeSpace);
                    created = "Недоступно";
                    modified = "Недоступно";
                    accessed = "Недоступно";
                }
                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    type = "Папка";
                    created = dirInfo.CreationTime.ToString();
                    modified = dirInfo.LastWriteTime.ToString();
                    accessed = dirInfo.LastAccessTime.ToString();
                }
            }
            else if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                type = GetFileType(fileInfo.Extension);
                size = FormatSize(fileInfo.Length);
                created = fileInfo.CreationTime.ToString();
                modified = fileInfo.LastWriteTime.ToString();
                accessed = fileInfo.LastAccessTime.ToString();
            }

            MessageBox.Show(
                $"Путь: {path}\n" +
                $"Тип: {type}\n" +
                $"Размер: {size}\n" +
                $"Дата создания: {created}\n" +
                $"Дата изменения: {modified}\n" +
                $"Дата последнего доступа: {accessed}",
                "Свойства",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка при получении информации: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
