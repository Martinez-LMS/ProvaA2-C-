public class Aluno
{
	public int Id { get; set; }  = Guid.NewGuid().ToString();
	public string Nome { get; set; }

    public int CPF { get; set; }

    public float peso { get; set; }

    public float altura { get; set; }

    public imc? imc{ get; set; }
	
}