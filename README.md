# EPAM.BSU.01.2016.Bytskevich.02

<b>Задание 1.</b><br> 
Разработать unit-тесты для тестирования метода Ньютона вычисления корня n-ой степени числа (задание предыдущего дня).<br>
<b><i>Выполнено:</i></b> (Visual Studio Unit Testing Framework tests + NUnit tests) https://github.com/YuliyaBytskevich/EPAM.BSU.01.2016.Bytskevich.01/commit/d55ecf09510af1dd6884bfb8468089f3156c032a


<b>Задание 2.</b><br>
Разработать тип, в котором реализовать алгоритм Евклида для вычисления НОД двух целых чисел (http://en.wikipedia.org/wiki/Euclidean_algorithm ). Метод должен также определять значение времени, необходимое для выполнения расчета. Добавить к разработанному типу дополнительную функциональность в виде перегруженных методов вычисления НОД для трех и т.д. целых чисел. <br>
Добавить к разработанному типу метод, реализующий алгоритм Стейна (бинарный алгоритм Эвклида) для расчета НОД двух целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm ). Метод должен также  определять значение времени, необходимое для выполнения расчетов. Добавить к разработанному типу дополнительную функциональность в виде перегруженных методов вычисления НОД для трех и т.д. целых чисел.<br>
Разработать unit-тесты для тестирования методов данного типа.


<b>Задание 3.</b> <br>
Расширить для целых чисел возможность форматного вывода, добавив представление в шестнадцатиричной системе счисления (класс Convert не использовать!). <br>
Разработать unit-тесты.


<b>Задание 4.</b><br>
Дан класс Customer, у которого есть строковые свойства Name, ContactPhone и свойство Revenue типа decimal. Реализовать для объектов данного класса возможность строкового представления различного вида.<br>
Например, для объекта со значениями Name = "Jeffrey Richter", Revenue = 1000000, ContactPhone = "+1 (425) 555-0100", могут быть следующие варианты: <br>
Customer record: Jeffrey Richter,  1,000,000.00, +1 (425) 555-0100<br>
Customer record: +1 (425) 555-0100<br>
Customer record: Jeffrey Richter, 1,000,000.00<br>
Customer record: Jeffrey Richter<br>
Customer record: 1000000 и т.д.<br>
Добавить для объектов данного класса дополнительную возможность форматирования (класс при этом не менять!), не предусмотренную классом. <br>
Разработать unit-тесты.<br>
