using System.Runtime.CompilerServices;

namespace task_manager.Models
{
    public enum EnumTaskStatus
    {
        Pendente,
        Finalizado   
    }

    public static class EnumTaskStatusExtension 
    { 

        public static string ToStatusString(EnumTaskStatus status)
        {
            return status switch
            {
                EnumTaskStatus.Pendente => "Pendente",
                EnumTaskStatus.Finalizado => "finalizado",
                _ => throw new ArgumentException("Status da Tarefa inválido")
            };
        }

        public static EnumTaskStatus ToTaskStatus(string status)
        {
            return status.Trim().ToLower() switch
            {
                "pendente" => EnumTaskStatus.Pendente,
                "finalizado" => EnumTaskStatus.Finalizado,
                _ => throw new ArgumentException("Status da Tarefa inválido")
            };
        }
    }
}
