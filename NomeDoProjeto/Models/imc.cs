public class imc
{
	public int Id { get; set; }  = Guid.NewGuid().ToString();
	public float peso { get; set; }
	public float altura { get; set; } public string? Status { get; set; } = "Não iniciada";
}