function buildTreeFromArray(a) {
	return $.ajax({
    		type: "POST",
    		data: JSON.stringify(a),
    		contentType: "application/json",
    		url:"http://localhost:4664/api/bstree"
    	});
}

function getTreeInfo(tree) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/tree_info"
	});
}

function insertX(tree, x) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/insert?x=" + x
	});
}

function findX(tree, x) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/find?x=" + x
	});
}

function getMaxFromApi(tree) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/max"
	});
}

function getMinFromApi(tree) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/min"
	});
}

function getMinOfRightFromApi(tree) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/minOfRight"
	});	
}

function getMaxOfLeftFromApi(tree) {
	return $.ajax({
		type: "POST",
		data: JSON.stringify(tree),
		contentType: "application/json",
		url:"http://localhost:4664/api/bstree/maxOfLeft"
	});	
}