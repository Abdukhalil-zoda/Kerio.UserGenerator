using System.Text;

while (true)
{
    Console.WriteLine("Enter fullname");
    var fullname = Console.ReadLine();

    var data = File.ReadAllText("C:\\Users\\Abdulaziz\\source\\repos\\Switch.Lib\\Test\\data.json").Replace("%USERNAME%", UserName(fullname!)).Replace("%FULLNAME%", fullname);

    HttpClient client = new HttpClient();

    var content = new StringContent(data, Encoding.UTF8, "application/json");

    client.DefaultRequestHeaders.Add("Cookie", "SESSION_CONTROL_WEBADMIN=4992efa91e91eec37059a1916b161171077a2f43f0b8f11e6cb24e08a80a4976; TOKEN_CONTROL_WEBADMIN=55c638dd8ed6ad839aca593e652024544712854c74c5731f690c695f9c381483");
    client.DefaultRequestHeaders.Add("X-Token", "55c638dd8ed6ad839aca593e652024544712854c74c5731f690c695f9c381483");

    await client.PostAsync("https://kerio.samps.uz/admin/api/jsonrpc/", content);
}

string UserName(string fullname)
{
    var firstname = fullname.Split()[1].ToLower();
    var lastname = fullname.Split()[0].ToLower();

    return $"{lastname}_{firstname[0]}";
}