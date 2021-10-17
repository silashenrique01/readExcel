using Domain;
using Domain.ReadExcel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReadExcel.Controllers
{
    [Route("api/receivefile")]
    [ApiController]
    public class ReceiveFileController : ControllerBase
    {
        public Teste teste = new Teste();
        public List<string> lista = new List<string>();
        public List<string> info = new List<string>();

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {


            if (file == null || file.Length == 0)
            {
                return RedirectToAction("");
            }

            using (var memoryStream = new MemoryStream())
            {
                file.CopyToAsync(memoryStream).ConfigureAwait(false);

                using (var package = new ExcelPackage(memoryStream))
                {

                    var totalRows = package.Workbook.Worksheets["exporta_vitima_28-05-2020-09-33"].Dimension?.Rows;
                    var totalColumns = package.Workbook.Worksheets["exporta_vitima_28-05-2020-09-33"].Dimension?.Columns;

                    if (totalRows != null && totalColumns != null)
                    {
                        for (int j = 0; j < totalRows.Value; j++)
                        {
                            if (j > 2)
                            {

                                for (int k = 0; k < 2; k++)
                                {
                                    var teste1 = package.Workbook.Worksheets["exporta_vitima_28-05-2020-09-33"].Cells.Value;
                                    var linha1 = ((object[,])teste1)[j, k];
                                    if (linha1 != null)
                                    {
                                        lista.Add(linha1.ToString());
                                    }
                                }

                            }
                          
                        }
                    }

                    var colunas = info.Count();




                    return Ok(lista);
                }

            }
        }
        private List<string> Teste4(List<string> list)
        {
            var lista = new List<string>();

            for (int i = 0; i < list.Count(); i++)
            {
                if (i < 49)
                {
                    lista.Add(info[i].ToString());
                }
            }
            return lista;
        }
        private List<string> Teste5(List<string> list)
        {
            var lista = new List<string>();

            for (int i = 0; i < list.Count(); i++)
            {
                if (i > 49 &&  i < 98)
                {
                    lista.Add(info[i].ToString());
                }
            }
            return lista;
        }
    }
}
