using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Common;
using System.Text.RegularExpressions;

namespace RRS_UI.Application_Code.Handler
{
    /// <summary>
    /// Summary description for UploadFileHandler
    /// </summary>
    public class UploadFileHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //getting Files Count sent by  ajax request to Handler
                if (context.Request.Files.Count > 0)
                {
                    //Creating Files Collection for all files
                    HttpFileCollection SelectedFiles = context.Request.Files;
                    //looping the Files List

                    int c = 0;
                    for (int i = 0; i < SelectedFiles.Count; i++)
                    {
                        //getting the File from the List and assigning it to PostedFile Objec
                        HttpPostedFile PostedFile = SelectedFiles[i];

                        //Getting File Name
                        System.IO.FileInfo file = new System.IO.FileInfo(PostedFile.FileName);
                        //string file_name = PostedFile.FileName + "_UserID_" + (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;

                        //Getting only File Name removing extentsion from the file name
                        string fname = file.Name.Remove((file.Name.Length - file.Extension.Length));

                        //appendingCurrent Date Time to File Name
                        fname = Regex.Replace(fname, @"\s+", "") + DateTime.Now.ToString("_mmddyyyy_HHmmss") + file.Extension;

                        //Getting The File Uploading Server Path
                        string SaveLocation = context.Server.MapPath(UtilityFunctions.ImportDocumentPath) + PostedFile.FileName;


                        //Saving The File to server
                        PostedFile.SaveAs(SaveLocation);

                        if (c > 0)
                        {
                            context.Session["ImportFilesName"] = context.Session["ImportFilesName"].ToString() + "," + PostedFile.FileName;
                        }
                        else
                        {
                            // the FileName in Session to get filename on save of the Form on which Document is uploaded
                            context.Session["ImportFilesName"] = PostedFile.FileName;
                        }

                        c = c + 1;
                    }
                }
                //handler Response
                context.Response.ContentType = "text/plain";
                context.Response.Write("");
            }
            catch (Exception ex)
            {

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}