//IIFE (function(){})();
(function verificarMsg() {
	if (msg) {
		toastr.info(msg, "FN Store");
	}
})();

//verificarMsg();

function excluir(id, nome) {
	//var isConfirm = confirm("Quer excluir o produto: " + nome + " ?");
	//let delProd = confirm(`Quer excluir o produto: "${nome}"?`);

	//if (delProd) {
	//	let xhr = new XMLHttpRequest();

	//	xhr.onloadend = function () {
	//		//console.log(xhr.status, xhr);
	//		if (xhr.status == 200) {
	//			let tr = document.querySelector("#item-" + id);

	//			if (!!tr)
	//				tr.remove();
	//			else
	//				alert("Erro ao excluir o produto");
	//		}
	//	};

	//	xhr.open("delete", "http://localhost:49835/Produtos/Delete/" + id);
	//	xhr.send();
	//}
	$("#delProdModal").modal('show');


	//js
	//document.querySelector("#nomeProd").textContent = nome;
	//document.querySelector("#delProdModal").getAttribute("data-id");
	//document.querySelector("#delProdModal").setAttribute("data-id", id);

	//jQuery
	$("#nomeProd")
		//.data("id", id)
		.text(nome);

	_id = id;
}

function confirmar() {
	//alert("ok - " + _id);
	//alert("ok - " + $("#nomeProd").data("id"));

	// Escopo do let é por contexto/bloco
	// Escopo do var é escopo da função
	$.ajax({
		url: `${_url}/${_id}`,
		type: "delete",
		success: () => {
			//alert("Excluído com sucesso");
			toastr.success("Excluído com sucesso", "FN Store");
			//document.querySelector("#item-" + _id).remove();
			$("#item-" + _id).remove();
		},
		//error: data => alert(data.responseText),
		error: data => toastr.error(data.responseText, "FN Store"),
		complete: _ => $("#delProdModal").modal('hide')
	});
}