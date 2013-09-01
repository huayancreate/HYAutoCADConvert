using AutoCAD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo.Bussiness
{
    public class DefaultTask : AbstractTask
    {
        public override void Run()
        {
            this.AcadDoc = this.AcAppComObj.Documents.Open(this.AbsPath, null, null);
            //TODO 相应方法
            AcadBlocks blocks = this.AcadDoc.Blocks;
            //1.获取要替换图号的规则
            HistoryDto dto = Util.GetDrwingsDto(AcadDoc.Name);
            try
            {
                foreach (AcadBlock block in blocks)
                {
                    foreach (AcadEntity entity in block)
                    {
                        //2.替换审核者、设计者、日期等属性
                        Util.ReplaceProperty(entity, blocks,this.GetDefaultRules());
                        //3.替换装配图中的明细表中的编号
                        Util.ReplaceDrawingCode(entity, AcAppComObj);
                        entity.Update();
                    }
                }
                dto.FileStatus = "处理完成";
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                Util.UpdateHistory(dto);
                var fileName = Util.SplitCode(Util.newCode);
                if (AcAppComObj.ActiveDocument.Saved == false)
                {
                    AcAppComObj.ActiveDocument.SaveAs(this.SavePath + fileName + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                    this.AcadDoc.Close();
                    GC.Collect();

                }
            }
            catch (Exception ex)
            {
                dto.FileStatus = "处理失败," + ex.Message;
                dto.FilePath = dto.FilePath.Replace("\\", "\\\\");
                Util.UpdateHistory(dto);
                AcAppComObj.ActiveDocument.SaveAs(this.SavePath + "失败的图纸文件" + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                this.AcadDoc.Close();
            }
        }
    }
}
