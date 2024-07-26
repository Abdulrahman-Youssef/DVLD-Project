using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Runtime.Remoting.Messaging;


    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        public static bool CreateFile(string FileName)
        {
            if (!Directory.Exists(FileName))
            {
                try
                {
                    Directory.CreateDirectory(FileName);
                    return true;
                }
                catch (IOException ex)  
                {
                    MessageBox.Show($"Error Creating file Name : {FileName} " + ex.Message);
                    return false;
                }
                
              
            }
            
            return true;
        }

        public static string ReplaceFileNameWithGUID(string FileName)
        {        
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            return GenerateGUID() + ext;
        }

        public static bool CopyImageToProjectImagesFolder(ref string  sourceFile)
        {
            string FilePath = @"E:\#4 Visual Studio Code Community\19 - Full Real Project\Images-project\";
            if (!CreateFile(FilePath))
            {
                return false;
            }

            string copiedFile = FilePath + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, copiedFile, true);
                sourceFile = copiedFile;  
                return true;
            }
            catch (IOException ex) 
            {
                MessageBox.Show("faild to copy file copyfilefuncname" +  ex.Message);
                return false;
            }


        }


    }

