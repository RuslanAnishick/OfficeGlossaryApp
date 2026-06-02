using GlossaryServer.Models;

namespace GlossaryServer.Data
{
    public static class SeedData
    {
        public static List<Term> GetTerms()
        {
            return new List<Term>
            {
                new Term { Title = "Дедлайн", Category = "Организация работы", Description = "Крайний срок выполнения задачи.", Example = "Дедлайн по проекту — пятница." },

                new Term { Title = "KPI", Category = "Управление", Description = "Ключевой показатель эффективности.", Example = "KPI отдела продаж вырос." },

                new Term { Title = "CRM", Category = "Информационные системы", Description = "Система управления клиентами.", Example = "Все заявки хранятся в CRM." },

                new Term { Title = "ERP", Category = "Информационные системы", Description = "Система управления ресурсами предприятия.", Example = "ERP объединяет отделы компании." },

                new Term { Title = "Бриф", Category = "Документы", Description = "Краткое описание задачи.", Example = "Дизайнер получил бриф." },

                new Term { Title = "Регламент", Category = "Документы", Description = "Описание рабочего процесса.", Example = "Работа выполняется по регламенту." },

                new Term { Title = "Планёрка", Category = "Коммуникации", Description = "Короткое рабочее совещание.", Example = "Утром была планёрка." },

                new Term { Title = "Тикет", Category = "Информационные системы", Description = "Заявка в техподдержку.", Example = "Создан тикет по проблеме." },

                new Term { Title = "Scrum", Category = "Управление проектами", Description = "Методология гибкой разработки.", Example = "Команда работает по Scrum." },

                new Term { Title = "Kanban", Category = "Управление проектами", Description = "Метод управления задачами.", Example = "Задачи распределены по Kanban." },

                new Term { Title = "Backlog", Category = "Управление проектами", Description = "Список задач проекта.", Example = "Задача попала в backlog." },

                new Term { Title = "Sprint", Category = "Управление проектами", Description = "Короткий цикл разработки.", Example = "Спринт длится две недели." },

                new Term { Title = "HR", Category = "Управление", Description = "Отдел управления персоналом.", Example = "HR проводит собеседование." },

                new Term { Title = "Онбординг", Category = "HR", Description = "Адаптация нового сотрудника.", Example = "Компания внедрила онбординг." },

                new Term { Title = "Soft Skills", Category = "HR", Description = "Гибкие навыки сотрудника.", Example = "Soft skills важны для менеджера." },

                new Term { Title = "Hard Skills", Category = "HR", Description = "Профессиональные навыки.", Example = "Hard skills программиста проверили." },

                new Term { Title = "Отчётность", Category = "Документы", Description = "Подготовка отчётов.", Example = "Сдана месячная отчётность." },

                new Term { Title = "Согласование", Category = "Организация работы", Description = "Процесс утверждения.", Example = "Документ отправлен на согласование." },

                new Term { Title = "Командировка", Category = "Организация работы", Description = "Служебная поездка.", Example = "Менеджер уехал в командировку." },

                new Term { Title = "Документооборот", Category = "Документы", Description = "Обработка документов.", Example = "Внедрён электронный документооборот." },

                new Term { Title = "Облачное хранилище", Category = "Информационные системы", Description = "Онлайн-хранение файлов.", Example = "Документы лежат в облаке." },

                new Term { Title = "VPN", Category = "Информационные системы", Description = "Защищённое сетевое соединение.", Example = "Сотрудник подключился через VPN." },

                new Term { Title = "Логин", Category = "Информационные системы", Description = "Имя пользователя.", Example = "Введите логин." },

                new Term { Title = "Пароль", Category = "Информационные системы", Description = "Средство аутентификации.", Example = "Пароль должен быть сложным." },

                new Term { Title = "Двухфакторная аутентификация", Category = "Безопасность", Description = "Дополнительная защита входа.", Example = "В компании включена 2FA." },

                new Term { Title = "База данных", Category = "Информационные системы", Description = "Хранилище структурированных данных.", Example = "Информация хранится в БД." },

                new Term { Title = "SQL", Category = "Информационные системы", Description = "Язык запросов к базам данных.", Example = "Разработчик написал SQL-запрос." },

                new Term { Title = "API", Category = "Информационные системы", Description = "Интерфейс взаимодействия систем.", Example = "Сайт работает через API." },

                new Term { Title = "JSON", Category = "Информационные системы", Description = "Формат обмена данными.", Example = "API возвращает JSON." },

                new Term { Title = "HTTP", Category = "Информационные системы", Description = "Протокол передачи данных.", Example = "Браузер использует HTTP." },

                new Term { Title = "HTTPS", Category = "Безопасность", Description = "Защищённая версия HTTP.", Example = "Сайт использует HTTPS." },

                new Term { Title = "Firewall", Category = "Безопасность", Description = "Сетевой экран.", Example = "Firewall блокирует угрозы." },

                new Term { Title = "Резервная копия", Category = "Безопасность", Description = "Копия данных для восстановления.", Example = "Создан backup базы." },

                new Term { Title = "Backup", Category = "Безопасность", Description = "Резервное копирование.", Example = "Backup выполняется ночью." },

                new Term { Title = "Контрагент", Category = "Управление", Description = "Партнёр по договору.", Example = "Контрагент подписал договор." },

                new Term { Title = "Бизнес-процесс", Category = "Управление", Description = "Последовательность действий.", Example = "Процесс автоматизирован." },

                new Term { Title = "Приказ", Category = "Документы", Description = "Распорядительный документ.", Example = "Подписан приказ." },

                new Term { Title = "Служебная записка", Category = "Документы", Description = "Внутренний документ.", Example = "Создана служебная записка." },

                new Term { Title = "Корпоративная почта", Category = "Информационные системы", Description = "Рабочая почта сотрудника.", Example = "Письмо отправлено на корпоративную почту." },

                new Term { Title = "Zoom", Category = "Коммуникации", Description = "Сервис видеоконференций.", Example = "Созвон прошёл в Zoom." },

                new Term { Title = "Teams", Category = "Коммуникации", Description = "Корпоративный мессенджер Microsoft.", Example = "Сообщение отправили в Teams." },

                new Term { Title = "Google Meet", Category = "Коммуникации", Description = "Сервис видеосвязи Google.", Example = "Встреча прошла в Google Meet." },

                new Term { Title = "Slack", Category = "Коммуникации", Description = "Корпоративный чат.", Example = "Команда общается в Slack." },

                new Term { Title = "Техническое задание", Category = "Документы", Description = "Описание требований к проекту.", Example = "Разработчик получил ТЗ." }
            };
        }
    }
}