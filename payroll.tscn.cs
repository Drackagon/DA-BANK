using Godot;
using System;

public partial class NewScript : Node
{
signal money_changed(new_amount: int)
signal payday_triggered(amount_paid: int)

var balance: int = 500
var base_salary: int = 100
//var tax_rate: float = 0.10 # 10% deduction

func add_money(amount: int) -> void:
	balance += amount
	money_changed.emit(balance)

func process_payroll() -> void:
	var taxes: int = int(base_salary * tax_rate)
	var net_pay: int = base_salary - taxes
	
	add_money(net_pay)
	payday_triggered.emit(net_pay)

}
