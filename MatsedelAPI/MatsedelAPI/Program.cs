using HtmlAgilityPack;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

string ers�ttStora� = "&#196;";
string ers�ttLilla� = "&#228;";
string ers�ttLilla� = "&#229;";
string ers�ttStora� = "&#214";
string ers�ttLilla� = "&#246;";
string ers�ttEMedApostrof�tH�ger = "&#233;";
string ers�ttEMedApostrof�tV�nster = "&#232;";
string ers�ttAMedApostrof�tV�nster = "&#232;";
string ers�ttApostrof�tH�ger = "&#180;";
string ers�ttCitattecken = "&quot;";

var url = "https://mpi.mashie.com/public/app/V%C3%A4xj%C3%B6%20kommun%20ny/6f5fa240";
var httpClient = new HttpClient();
var html = await httpClient.GetStringAsync(url);

var htmlDocument = new HtmlDocument();
htmlDocument.LoadHtml(html);
var divNodeMatr�tter = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("app-daymenu-name")).ToList();

foreach (var div in divNodeMatr�tter)
{
    string modifiedString1 = div.InnerText.Replace(ers�ttStora�, "�");
    string modifiedString2 = modifiedString1.Replace(ers�ttLilla�, "�");
    string modifiedString3 = modifiedString2.Replace(ers�ttLilla�, "�");
    string modifiedString4 = modifiedString3.Replace(ers�ttStora�, "�");
    string modifiedString5 = modifiedString4.Replace(ers�ttLilla�, "�");
    string modifiedString6 = modifiedString5.Replace(ers�ttEMedApostrof�tH�ger, "�");
    string modifiedString7 = modifiedString6.Replace(ers�ttEMedApostrof�tV�nster, "�");
    string modifiedString8 = modifiedString7.Replace(ers�ttAMedApostrof�tV�nster, "�");
    string modifiedString9 = modifiedString8.Replace(ers�ttApostrof�tH�ger, "�");
    string modifiedString10 = modifiedString9.Replace(ers�ttCitattecken, "\"");

    Console.WriteLine(modifiedString10);
}

var divNodeDatum = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("panel-heading")).ToList();

foreach (var div in divNodeDatum)
{
    string modifiedString1 = div.InnerText.Replace(ers�ttStora�, "�");
    string modifiedString2 = modifiedString1.Replace(ers�ttLilla�, "�");
    string modifiedString3 = modifiedString2.Replace(ers�ttLilla�, "�");
    string modifiedString4 = modifiedString3.Replace(ers�ttStora�, "�");
    string modifiedString5 = modifiedString4.Replace(ers�ttLilla�, "�");

    Console.WriteLine(modifiedString5);
}

var divNodeVecka = htmlDocument.DocumentNode.Descendants("h4").Where(node => node.GetAttributeValue("class", "").Contains("app-week")).ToList();

foreach (var div in divNodeVecka)
{
    Console.WriteLine(div.InnerText);
}