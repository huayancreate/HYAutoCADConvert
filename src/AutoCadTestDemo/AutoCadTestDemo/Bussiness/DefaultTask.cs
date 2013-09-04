using AutoCAD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;

namespace AutoCadTestDemo.Bussiness
{

    public class DefaultTask : AbstractTask
    {

        private System.Timers.Timer aTimer;

        public override void Run(object state)
        {
            //aTimer = new System.Timers.Timer();
            this.flag = false;

            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 5000;
            //aTimer.Enabled = true;
            //TODO 相应方法
            AcadBlocks blocks = this.AcadDoc.Blocks;
            this.flag = true;
            //1.获取要替换图号的规则
            HistoryDto dto = this.Util.GetDrwingsDto(AcadDoc.Name);
            //try
            //{
                foreach (AcadBlock block in blocks)
                {
                    foreach (AcadEntity entity in block)
                    {
                        //2.替换审核者、设计者、日期等属性
                        this.Util.ReplaceProperty(entity, blocks, this.GetDefaultRules());
                        //3.替换装配图中的明细表中的编号
                        this.Util.ReplaceDrawingCode(entity, AcAppComObj);
                        entity.Update();
                    }
                }
                dto.FileStatus = "处理完成";
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                this.Util.UpdateHistory(dto);
                var fileName = this.Util.SplitCode(this.Util.newCode);
                System.Console.WriteLine("Util.newCode = " + this.Util.newCode);
                System.Console.WriteLine("fileName = " + fileName);
                System.Console.WriteLine("item = " + AcAppComObj.Documents.Count);
                System.Console.WriteLine("currentItem = " + Item);
                this.SaveName = this.SavePath + fileName + "\\" + this.Util.newCode;
                System.Console.WriteLine("SaveName = " + SaveName);
                this.Save();
                //if (AcAppComObj.Documents.Item(Item).Saved == false)
                //{
                //    System.Console.WriteLine("this.SavePath + fileName + Util.newCode = " + this.SavePath + fileName + "\\" + Util.newCode);
                //    AcAppComObj.Documents.Item(Item).SaveAs(this.SavePath + fileName + "\\" + this.Util.newCode, AcSaveAsType.ac2013_dwg, null);
                //    this.AcadDoc.Close();
                //    GC.Collect();

                //}
            //}
            //catch (Exception ex)
            //{
            //    dto.FileStatus = "处理失败," + ex.Message;
            //    dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
            //    Util.UpdateHistory(dto);
            //    AcAppComObj.Documents.Item(Item).SaveAs(this.SavePath + "失败的图纸文件" + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
            //    this.AcadDoc.Close();
            //}
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            aTimer.Stop();
            if (!this.flag)
            {
                System.Diagnostics.Process[] killprocess = System.Diagnostics.Process.GetProcessesByName("acad");
                foreach (System.Diagnostics.Process p in killprocess)
                {
                    p.Kill();
                }
            }
        }
    }

}
