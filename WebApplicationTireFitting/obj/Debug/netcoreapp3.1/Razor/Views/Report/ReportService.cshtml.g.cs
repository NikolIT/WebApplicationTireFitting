#pragma checksum "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6daf7c6e5cbb432d853f96fd0051b4ee3e394db5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_ReportService), @"mvc.1.0.view", @"/Views/Report/ReportService.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\_ViewImports.cshtml"
using WebApplicationTireFitting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\_ViewImports.cshtml"
using WebApplicationTireFitting.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6daf7c6e5cbb432d853f96fd0051b4ee3e394db5", @"/Views/Report/ReportService.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fccaeb68d2719793a73ad743b3c8391a710cc9c", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_ReportService : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplicationTireFitting.Controllers.ReportService>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"box wide hidden-on-narrow\">\r\n    <div class=\"box-col\">\r\n        <button id=\"downloadPDF\" class=\'export-pdf k-button\'>Завантажити графік у PDF</button>\r\n    </div>\r\n</div>\r\n\r\n<div id=\"content\">\r\n    <h4>Звіт по послугам за ");
#nullable restore
#line 10 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                       Write(ViewBag.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <h4>Графік: популярність послуг</h4>\r\n    <div id=\"chartdiv\"></div>\r\n</div>\r\n\r\n\r\n\r\n<button type=\"button\" class=\"k-button\" id=\"printGrid\">Друкувати таблицю</button>\r\n\r\n");
#nullable restore
#line 19 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
Write(Html.Kendo().Grid(Model)
        .Name("Grid")
        .ToolBar(tools => { tools.Pdf().Text("Завантажити у PDF"); })
        .Pdf(pdf => pdf
                .AllPages()
                .AvoidLinks()
                .PaperSize("A4")
                .Margin("2cm", "1cm", "1cm", "1cm")
                .Landscape()
                .RepeatHeaders()
                .TemplateId("page-template")
                .FileName("ReportService.pdf")
        )
        .Columns(columns =>
        {
            columns.Bound(p => p.ser.ServiceName).Title("Назва");    
            columns.Bound(p => p.ser.Price).Title("Ціна");
            columns.Bound(p => p.orderCount).Title("Кількість замовлень").Width(200);

        }).HtmlAttributes(new { style = "height: 550px;" })
            .Scrollable()
            .Groupable()
            .Scrollable(scr => scr.Height(430))
            .Filterable()
            .Pageable(pageable => pageable
                .Refresh(true)
                .PageSizes(true)
                .ButtonCount(5))
            .DataSource(dataSource => dataSource
                .Ajax()
                .PageSize(20)
                .ServerOperation(false)
            )
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6daf7c6e5cbb432d853f96fd0051b4ee3e394db56338", async() => {
                WriteLiteral("Назад");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"x/kendo-template\" id=\"page-template\">\r\n    <div class=\"page-template\">\r\n        <div class=\"header\">\r\n            <div style=\"float: left\">Звіт по популярності посгуг</div>\r\n            <div style=\"float: right\">Date: ");
#nullable restore
#line 58 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                                       Write(ViewBag.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  Page #: pageNum # of #: totalPages #</div>
        </div>
        <div class=""footer"" style = ""background-color:white;"">
            Page #: pageNum # of #: totalPages #
        </div>
    </div>
</script>

<script>
    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create(""chartdiv"", am4charts.XYChart);

        // Add data
        var data = [
");
#nullable restore
#line 78 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
              
                foreach (var item in Model)
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        {\r\n                            \"country\": \"");
#nullable restore
#line 83 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                                   Write(item.ser.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                            \"research\": ");
#nullable restore
#line 84 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                                   Write(item.orderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                        },\r\n                    ");
#nullable restore
#line 86 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                           
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        ];

        chart.data = data;
        // Create axes
        var categoryAxis = chart.yAxes.push(new am4charts.CategoryAxis());
        categoryAxis.dataFields.category = ""country"";
        categoryAxis.renderer.grid.template.location = 0;
        categoryAxis.renderer.minGridDistance = 10;
        categoryAxis.interpolationDuration = 2000;

        var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());

        // Create series
        function createSeries(field, name) {
            var series = chart.series.push(new am4charts.ColumnSeries());
            series.dataFields.valueX = ""research"";
            series.dataFields.categoryY = ""country"";
            series.columns.template.tooltipText = ""[bold]{valueX}[/]"";
            series.columns.template.cursorOverStyle = am4core.MouseCursorStyle.pointer;

            var hs = series.columns.template.states.create(""hover"");
            hs.properties.fillOpacity = 0.7;

            var columnTemplate = series.columns.templat");
            WriteLiteral(@"e;
            columnTemplate.maxX = 0;
            columnTemplate.draggable = true;

            columnTemplate.events.on(""dragstart"", function (ev) {
                var dataItem = ev.target.dataItem;

                var axislabelItem = categoryAxis.dataItemsByCategory.getKey(
                    dataItem.categoryY
                )._label;
                axislabelItem.isMeasured = false;
                axislabelItem.minX = axislabelItem.pixelX;
                axislabelItem.maxX = axislabelItem.pixelX;

                axislabelItem.dragStart(ev.target.interactions.downPointers.getIndex(0));
                axislabelItem.dragStart(ev.pointer);
            });
            columnTemplate.events.on(""dragstop"", function (ev) {
                var dataItem = ev.target.dataItem;
                var axislabelItem = categoryAxis.dataItemsByCategory.getKey(
                    dataItem.categoryY
                )._label;
                axislabelItem.dragStop();
                handleDragS");
            WriteLiteral(@"top(ev);
            });
        }
        createSeries(""research"", ""Research"");

        function handleDragStop(ev) {
            data = [];
            chart.series.each(function (series) {
                if (series instanceof am4charts.ColumnSeries) {
                    series.dataItems.values.sort(compare);

                    var indexes = {};
                    series.dataItems.each(function (seriesItem, index) {
                        indexes[seriesItem.categoryY] = index;
                    });

                    categoryAxis.dataItems.values.sort(function (a, b) {
                        var ai = indexes[a.category];
                        var bi = indexes[b.category];
                        if (ai == bi) {
                            return 0;
                        } else if (ai < bi) {
                            return -1;
                        } else {
                            return 1;
                        }
                    });

              ");
            WriteLiteral(@"      var i = 0;
                    categoryAxis.dataItems.each(function (dataItem) {
                        dataItem._index = i;
                        i++;
                    });

                    categoryAxis.validateDataItems();
                    series.validateDataItems();
                }
            });
        }

        function compare(a, b) {
            if (a.column.pixelY < b.column.pixelY) {
                return 1;
            }
            if (a.column.pixelY > b.column.pixelY) {
                return -1;
            }
            return 0;
        }

    }); // end am4core.ready()
    // Import DejaVu Sans font for embedding

    // NOTE: Only required if the Kendo UI stylesheets are loaded
    // from a different origin, e.g. cdn.kendostatic.com
    kendo.pdf.defineFont({
        ""DejaVu Sans"": ""https://kendo.cdn.telerik.com/2016.2.607/styles/fonts/DejaVu/DejaVuSans.ttf"",
        ""DejaVu Sans|Bold"": ""https://kendo.cdn.telerik.com/2016.2.607/styles/fon");
            WriteLiteral(@"ts/DejaVu/DejaVuSans-Bold.ttf"",
        ""DejaVu Sans|Bold|Italic"": ""https://kendo.cdn.telerik.com/2016.2.607/styles/fonts/DejaVu/DejaVuSans-Oblique.ttf"",
        ""DejaVu Sans|Italic"": ""https://kendo.cdn.telerik.com/2016.2.607/styles/fonts/DejaVu/DejaVuSans-Oblique.ttf"",
        ""WebComponentsIcons"": ""https://kendo.cdn.telerik.com/2017.1.223/styles/fonts/glyphs/WebComponentsIcons.ttf""
    });

    function printGrid() {
        var gridElement =
            printableContent = `
            <thead>
				<tr>
					<th>Назва</th>
                    <th>Ціна</th>
                    <th>Кількість замовлень</th>
				</tr>
			</thead>
            <tbody>

");
#nullable restore
#line 210 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 213 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ser.ServiceName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 214 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ser.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 215 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
                   Write(Html.DisplayFor(modelItem => item.orderCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 217 "C:\Users\nikol\source\repos\WebApplicationTireFitting\WebApplicationTireFitting\Views\Report\ReportService.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"`,
            win = window.open('', '', 'width=800, height=500, resizable=1, scrollbars=1'),
            doc = win.document.open();


        var htmlStart =
            `
            <!DOCTYPE html>
            <html>
	            <head>
		        <meta charset=""utf-8"">
<style>
    body {
        margin: 20px;
        padding: 0;
    }

    table {
        width: 100%; /*Ширина таблицы*/
        margin-bottom: 18px; /*Отступ снизу от таблицы*/
        padding: 0; /*Отступы внутри таблицы*/
        font-size: 13px; /*Размер шрифта*/
        border: 1px solid #dddddd; /*Граница таблицы*/
        border-spacing: 0; /*Отступы между границами ячеек*/
        border-collapse: separate; /*Границы ячеек не склеиваются*/
        -webkit-border-radius: 5px; /*Радиус скругления углов у таблицы Safari, Chrome*/
        -moz-border-radius: 5px; /*Радиус скругления углов у таблицы Mozilla*/
        border-radius: 5px; /*Радиус скругления углов у таблицы*/
        color: #666666; /*Цвет текста ");
            WriteLiteral(@"в таблице*/
        font-family: Arial; /*Семейство шрифтов*/
    }

        table th, table td {
            padding: 10px 10px 9px; /*Отступы внутри ячеек*/
            line-height: 18px; /*Межстрочный интервал*/
            text-align: left; /*Выравнивание текста по левому краю*/
        }

        table th {
            padding-top: 9px; /*Отступы внутри ячеек*/
            font-weight: bold; /*Установка жирного начертания шрифта*/
            vertical-align: middle; /*Выравнивание по вертикали. Текст находится по середине*/
            color: black; /*Черный цвет в ячейках заголовков таблицы*/
        }

        table td {
            vertical-align: top; /*Выравнивание содержимого ячейки по верхнему краю*/
            border-top: 1px solid #ddd; /*Верхняя граница ячейки*/
        }

            table th + th, table td + td, table th + td {
                border-left: 1px solid #ddd; /*Стиль для левой границы между двумя ячейками*/
            }

        table thead tr:first-ch");
            WriteLiteral(@"ild th:first-child, /*Первая строка первая ячейка в заголовке таблицы*/
        table tbody tr:first-child td:first-child /*Первая строка первая ячейка в теле таблицы*/ {
            -webkit-border-radius: 5px 0 0 0;
            -moz-border-radius: 5px 0 0 0;
            border-radius: 5px 0 0 0;
        }

        table thead tr:first-child th:last-child, /*Первая строка последняя ячейка в заголовке таблицы*/
        table tbody tr:first-child td:last-child /*Первая строка последняя ячейка в теле таблицы*/ {
            -webkit-border-radius: 0 5px 0 0;
            -moz-border-radius: 0 5px 0 0;
            border-radius: 0 5px 0 0;
        }

        table tbody tr:last-child td:first-child /*Последняя строка первая ячейка в теле таблицы*/ {
            -webkit-border-radius: 0 0 0 5px;
            -moz-border-radius: 0 0 0 5px;
            border-radius: 0 0 0 5px;
        }

        table tbody tr:last-child td:last-child /*Последняя строка последняя ячейка в теле таблицы*/ {
        ");
            WriteLiteral(@"    -webkit-border-radius: 0 0 5px 0;
            -moz-border-radius: 0 0 5px 0;
            border-radius: 0 0 5px 0;
        }

        table tr:hover {
            background-color: #f2f2f2; /*Цвет строки при наведении курсора мыши*/
        }
</style>
		            <title>Звіт</title>
	        </head>
	        <body>
		        <table>

            `;

        var htmlEnd =
            `
                        </tbody>
                    </table>
	            </body>
            </html>`;


        doc.write(htmlStart + printableContent + htmlEnd);
        doc.close();
        win.print();

    }
    $('#printGrid').click(function () {
        printGrid();
    });

    //скачування PDF графіку
    $('#downloadPDF').click(function () {
        domtoimage.toPng(document.getElementById('content'))
            .then(function (blob) {
                //var pdf = new jsPDF('p', 'pt', ""a4"");
                var pdf = new jsPDF('l', 'pt', [$('#content').width(), $('#content'");
            WriteLiteral(").height()]);\r\n                pdf.addImage(blob, \'PNG\', 0, 0, $(\'#content\').width(), $(\'#content\').height());\r\n                pdf.save(\"ReportService.pdf\");\r\n            });\r\n    });\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplicationTireFitting.Controllers.ReportService>> Html { get; private set; }
    }
}
#pragma warning restore 1591
