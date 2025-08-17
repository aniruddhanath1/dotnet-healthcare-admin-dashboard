<?php

namespace App\Services;

use App\Repositories\AppointmentRepository;

class AppointmentService
{
    protected $repo;

    public function __construct(AppointmentRepository $repo)
    {
        $this->repo = $repo;
    }

    // SQL (DTO-based)
    public function getAll()
    {
        return $this->repo->getAll();
    }

    public function getById($id)
    {
        return $this->repo->getById($id);
    }

    public function add($data)
    {
        return $this->repo->add($data);
    }

    public function update($id, $data)
    {
        return $this->repo->update($id, $data);
    }

    public function delete($id)
    {
        return $this->repo->delete($id);
    }

    // MongoDB
    public function getAllMongo()
    {
        return $this->repo->getAllMongo();
    }

    public function getByIdMongo($id)
    {
        return $this->repo->getByIdMongo($id);
    }

    public function addMongo($data)
    {
        return $this->repo->addMongo($data);
    }

    public function updateMongo($id, $data)
    {
        return $this->repo->updateMongo($id, $data);
    }

    public function deleteMongo($id)
    {
        return $this->repo->deleteMongo($id);
    }
}
