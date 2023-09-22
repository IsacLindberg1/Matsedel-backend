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

string ersättStoraÄ = "&#196;";
string ersättLillaÄ = "&#228;";
string ersättLillaÅ = "&#229;";
string ersättStoraÖ = "&#214";
string ersättLillaÖ = "&#246;";
string ersättEMedApostrofÅtHöger = "&#233;";
string ersättEMedApostrofÅtVänster = "&#232;";
string ersättAMedApostrofÅtVänster = "&#232;";
string ersättApostrofÅtHöger = "&#180;";
string ersättCitattecken = "&quot;";

var url = "https://mpi.mashie.com/public/app/V%C3%A4xj%C3%B6%20kommun%20ny/6f5fa240";
var httpClient = new HttpClient();
var html = await httpClient.GetStringAsync(url);

var htmlDocument = new HtmlDocument();
htmlDocument.LoadHtml(html);
var divNodeMaträtter = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("app-daymenu-name")).ToList();

foreach (var div in divNodeMaträtter)
{
    string modifiedString1 = div.InnerText.Replace(ersättStoraÄ, "Ä");
    string modifiedString2 = modifiedString1.Replace(ersättLillaÄ, "ä");
    string modifiedString3 = modifiedString2.Replace(ersättLillaÅ, "å");
    string modifiedString4 = modifiedString3.Replace(ersättStoraÖ, "Ö");
    string modifiedString5 = modifiedString4.Replace(ersättLillaÖ, "ö");
    string modifiedString6 = modifiedString5.Replace(ersättEMedApostrofÅtHöger, "é");
    string modifiedString7 = modifiedString6.Replace(ersättEMedApostrofÅtVänster, "è");
    string modifiedString8 = modifiedString7.Replace(ersättAMedApostrofÅtVänster, "à");
    string modifiedString9 = modifiedString8.Replace(ersättApostrofÅtHöger, "´");
    string modifiedString10 = modifiedString9.Replace(ersättCitattecken, "\"");

    Console.WriteLine(modifiedString10);
}

var divNodeDatum = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("panel-heading")).ToList();

foreach (var div in divNodeDatum)
{
    string modifiedString1 = div.InnerText.Replace(ersättStoraÄ, "Ä");
    string modifiedString2 = modifiedString1.Replace(ersättLillaÄ, "ä");
    string modifiedString3 = modifiedString2.Replace(ersättLillaÅ, "å");
    string modifiedString4 = modifiedString3.Replace(ersättStoraÖ, "Ö");
    string modifiedString5 = modifiedString4.Replace(ersättLillaÖ, "ö");

    Console.WriteLine(modifiedString5);
}

var divNodeVecka = htmlDocument.DocumentNode.Descendants("h4").Where(node => node.GetAttributeValue("class", "").Contains("app-week")).ToList();

foreach (var div in divNodeVecka)
{
    Console.WriteLine(div.InnerText);
}